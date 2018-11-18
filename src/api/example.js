import resource from 'resource-router-middleware';
import examples from '../models/examples';

export default ({ config, db }) => resource({

	/** Property name to store preloaded entity on `request`. */
	id : 'example',

	/** For requests with an `id`, you can auto-load the entity.
	 *  Errors terminate the request, success sets `req[id] = data`.
	 */
	load(req, id, callback) {
		let example = examples.find( example => example.id===id ),
			err = example ? null : 'Not found';
		callback(err, example);
	},

	/** GET / - List all entities */
	index({ params }, res) {
		res.json(examples);
	},

	/** POST / - Create a new entity */
	create({ body }, res) {
		body.id = examples.length.toString(36);
		examples.push(body);
		res.json(body);
	},

	/** GET /:id - Return a given entity */
	read({ example }, res) {
		res.json(example);
	},

	/** PUT /:id - Update a given entity */
	update({ example, body }, res) {
		for (let key in body) {
			if (key!=='id') {
				example[key] = body[key];
			}
		}
		res.sendStatus(204);
	},

	/** DELETE /:id - Delete a given entity */
	delete({ example }, res) {
		examples.splice(examples.indexOf(example), 1);
		res.sendStatus(204);
	}
});