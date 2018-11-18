import { version } from '../../package.json';
import { Router } from 'express';
import examples from './example';

export default ({ config, db }) => {
	let api = Router();

	// mount the example resource
	api.use('/example', examples({ config, db }));

	// perhaps expose some API metadata at the root
	api.get('/', (req, res) => {
		res.json({ version });
	});

	return api;
}